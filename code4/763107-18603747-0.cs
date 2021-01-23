		public static void Main(string[] args)
		{
			var lengths = new List<decimal>(new decimal[] { 42.09m, 32.36m, 46.77m, 44.17m, 20.55m, 18.46m, 30.28m, 22.76m }); 
			var lst = new List<Solution>(); 
			for (int i = 0; i < lengths.Count; i++) { 
				lst.Add(new Solution(new decimal[] { lengths[i] }));  
				for (int j = 0; j < lengths.Count; j++) { 
					lst.Add(new Solution(new decimal[] { lengths[i], lengths[j] })); 
					for (int k = 0; k < lengths.Count; k++) { 
						lst.Add(new Solution(new decimal[] { lengths[i], lengths[j], lengths[k] })); 
						for (int l = 0; l < lengths.Count; l++) { 
							lst.Add(new Solution(new decimal[] { lengths[i], lengths[j], lengths[k], lengths[l] })); 
						}
					}
				}
			}
			var validSolution = (from sln in lst
					 			 where sln.Value <= 120.00m
									&& sln.IsValid
								 select sln).OrderByDescending(sln => sln.Value)
								.First(); 
			Console.WriteLine(validSolution); 
		}
