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
				myMethod = SpeechFactory.GetSpeechMethod("Thank you");
				myMethod.Invoke(methods, null);
				myMethod = SpeechFactory.GetSpeechMethod("Say something funny");
				myMethod.Invoke(methods, null);
				myMethod = SpeechFactory.GetSpeechMethod("I said funny dammit!");
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
			[Speech("Thank you")]
			[Speech("Thank you Jarvis")]
			[Speech("Thanks")]
			public void YourWelcome()
			{
				JARVIS.Speak("You're Welcome Sir"); 
			}
			[Speech("Say something funny")]
			public void SayFunny()
			{
				JARVIS.Speak("A priest, a rabbi and a cabbage walk into a bar"); 
			}
			[Speech("I said funny dammit!")]
			public void TryFunnyAgain()
			{
				JARVIS.Speak("My apologies sir."); 
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
