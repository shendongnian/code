    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Text;
    using System.Collections.Concurrent;
    
    namespace ConsoleApplication1
    {
    	internal class Program
    	{
    		// Used http://stackoverflow.com/a/20285267/40868 as a template 
    		private static readonly Random Seed = new Random(42); //used a constant to keep result consistant
    		private static readonly string OutputFormat = "{0, -20} | {1, 8} | {2, 5}";
    
    		private static string BuildRandomInputString(int length)
    		{
    			var input = new StringBuilder();
    			for (var i = 0; i < length; i++)
    			{
    				var randomNumber = Seed.Next(0, 3);
    				var character = randomNumber == 0 ? 'A' : randomNumber == 1 ? 'B' : 'C';
    
    				input.Append(character);
    			}
    			return input.ToString();
    		}
    
    		private static List<string> BuildRandomReplacements(int replacementsCount)
    		{
    			var replacements = new List<string>();
    			for (var i = 0; i < replacementsCount; i++)
    			{
    				var randomNumber = Seed.Next(0, 3);
    				var replaceIteration = randomNumber == 0 ? "AB" : randomNumber == 1 ? "BC" : "CD";
    
    				replacements.Add(replaceIteration);
    			}
    			return replacements;
    		}
    
    		private static void TestImplementation(string implementationName, Action implementation)
    		{
    			GC.Collect();
    			GC.WaitForPendingFinalizers();
    
    			var stopWatch = Stopwatch.StartNew();
    			implementation();
    			stopWatch.Stop();
    
    			var executionTime = stopWatch.ElapsedMilliseconds;
    
    			stopWatch = Stopwatch.StartNew();
    			GC.Collect();
    			GC.WaitForPendingFinalizers();
    			stopWatch.Stop();
    
    			var gcTime = stopWatch.ElapsedMilliseconds;
    
    			Console.WriteLine(OutputFormat, implementationName, executionTime, gcTime);
    		}
    
    		private static void SimpleImplementation(string input, string replace, IList<string> replacements)
    		{
    			foreach (var replaceBy in replacements)
    			{
    				var result = input.Replace(replace, replaceBy);
    			}
    		}
    
    		private static void SimpleParallelImplementation(string input, string replace, IList<string> replaceBy)
    		{
    			var rangePartitioner = Partitioner.Create(0, replaceBy.Count);
    
    			Parallel.ForEach(rangePartitioner, (range, loopState) =>
    			{
    				for (var i = range.Item1; i < range.Item2; i++)
    				{
    					var result = input.Replace(replace, replaceBy[i]);
    				}
    			});
    		}
    
    		private static void ParallelSubstringImplementation(string input, string replace, string[] replaceBy)
    		{
    			var startingPosition = 0;
    			var indexes = new List<int>();
    
    			int currentPosition;
    
    			while ((currentPosition = input.IndexOf(replace, startingPosition)) >= 0)
    			{
    				indexes.Add(currentPosition);
    				startingPosition = currentPosition + 1;
    			}
    
    			var replaceByPartitioner = Partitioner.Create(0, replaceBy.Length);
    			var rangePartitioner = Partitioner.Create(0, indexes.Count);
    
    			Parallel.ForEach(replaceByPartitioner, (outerRange, outerLoopState) =>
    			{
    				for (var g = outerRange.Item1; g < outerRange.Item2; g++)
    				{
    					var replaceWith = replaceBy[g];
    
    					var finalSize = input.Length - (indexes.Count * replace.Length) + (indexes.Count * replaceWith.Length);
    					var finalResult = new char[finalSize];
    
    					Parallel.ForEach(rangePartitioner, (innerRange, innerLoopState) =>
    					{
    						for (var i = innerRange.Item1; i < innerRange.Item2; i++)
    						{
    							var currentIndex = indexes[i];
    							var prevIndex = i > 0 ? indexes[i - 1] : -replace.Length;
    
    							var n = 0;
    							if (prevIndex >= 0)
    							{
    								n = prevIndex + replace.Length;
    
    								// note that due to offset changes,
    								// prevIndex doesn't map to 1:1 if lens are different
    								if (replace.Length != replaceWith.Length)
    								{
    									var offset = (replace.Length - replaceWith.Length) * i;
    									var dir = replace.Length < replaceWith.Length;
    									n = prevIndex + offset + replaceWith.Length + (dir ? 1 : -1);
    								}
    							}
    
    							// append everything between two indexes.
    							for (var k = prevIndex + replace.Length; k < currentIndex; k++)
    								finalResult[n++] = input[k];
    
    							// append replaced text.
    							foreach (var ch in replaceWith)
    								finalResult[n++] = ch;
    
    							// if dealing with last index.
    							// we need to append remaining parts
    							if (currentIndex == indexes[indexes.Count - 1])
    							{
    								for (var k = currentIndex + replace.Length; k < input.Length; k++)
    									finalResult[n++] = input[k];
    							}
    						}
    					});
    				}
    			});
    		}
    
    		private static void FredouImplementation(string input, int inputLength, string replace, string[] replaceBy)
    		{
    			var output = new string[replaceBy.Length];
    
    			for (var i = 0; i < replaceBy.Length; ++i)
    				output[i] = string.Copy(input);
    
    			Parallel.For(0, replaceBy.Length, l => Process(output[l], input, inputLength, replace, replaceBy[l]));
    		}
    
    		private unsafe static void Process(string ouput, string input, int len, string replace, string replaceBy)
    		{
    			fixed (char* o = ouput, i = input, r = replace)
    			{
    				while (len > -1)
    				{
    					if (len > 0 && i[len] == r[1] && i[len - 1] == r[0])
    					{
    						o[len] = replaceBy[0]; o[--len] = replaceBy[1];
    					}
    					--len;
    				}
    			}
    		}
    
    
    		private static void Main()
    		{
    			const string replace = "BC";
    
    			var replacements = BuildRandomReplacements(500);
    			var input = BuildRandomInputString((int)Math.Pow(10, 6)); // length=1MB but space consumed=2MB(1char=2bytes)
    
    			var replacementsArray = replacements.ToArray();
    
    			Console.WriteLine(OutputFormat, "IMPLEMENTATION", "EXEC MS", "GC MS");
    			TestImplementation("#1 Simple", () => SimpleImplementation(input, replace, replacements));
    			TestImplementation("#2 Simple parallel", () => SimpleParallelImplementation(input, replace, replacements));
    			TestImplementation("#3 ParallelSubstring", () => ParallelSubstringImplementation(input, replace, replacementsArray));
    			TestImplementation("#4 Fredou I", () => FredouImplementation(input, input.Length, replace, replacementsArray));
    
    			Console.ReadKey();
    		}
    	}
    }
