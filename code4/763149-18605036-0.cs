	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using MyApp.SpeechMethods;
	namespace MyApp
	{
		class Program
		{
			static void Main(string[] args)
			{
				var methods = new MySpeechMethods();
				MethodInfo myMethod;
				myMethod = SpeechFactory.GetSpeechMethod("Time Please");
				myMethod.Invoke(methods, null);
				myMethod = SpeechFactory.GetSpeechMethod("Volume Down");
				myMethod.Invoke(methods, null);
				myMethod = SpeechFactory.GetSpeechMethod("Volume Up");
				myMethod.Invoke(methods, null);
			}
		}
		public static class SpeechFactory
		{
			private static Dictionary<string, MethodInfo> speechMethods = new Dictionary<string, MethodInfo>();
			public static MethodInfo GetSpeechMethod(string speechText)
			{
				MethodInfo methodInfo;
				var mySpeechMethods = new MySpeechMethods();
				if (speechMethods.Count == 0)
				{
					var methodNames =
						typeof (MySpeechMethods).GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
					var speechAttributeMethods = methodNames.Where(y => y.GetCustomAttributes().OfType<SpeechAttribute>().Any());
					foreach (var speechAttributeMethod in speechAttributeMethods)
					{
						foreach (var attribute in speechAttributeMethod.GetCustomAttributes(true))
						{
							speechMethods.Add(((SpeechAttribute)attribute).SpeechValue, speechAttributeMethod);
						}
					}
					methodInfo = speechMethods[speechText];
				}
				else
				{
					methodInfo = speechMethods[speechText];
				}
				return methodInfo;
			}
		}
	}
	namespace MyApp.SpeechMethods
	{
		public class MySpeechMethods
		{
			[Speech("Time Please")]
			[Speech("Whats the Time")]
			[Speech("What Time is it")]
			public void GetTime()
			{
				Console.WriteLine(DateTime.Now.ToLocalTime());
			}
			[Speech("Volume Down")]
			public void VolumeDown()
			{
				Console.WriteLine("Volume Down 1");
			}
			[Speech("Volume Up")]
			public void VolumeUp()
			{
				Console.WriteLine("Volume Up 1");
			}
		}
		[System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true)]
		public class SpeechAttribute : System.Attribute
		{
			public string SpeechValue { get; set; }
			public SpeechAttribute(string textValue)
			{
				this.SpeechValue = textValue;
			}
		}
	}
