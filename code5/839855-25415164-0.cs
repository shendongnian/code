    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Text.RegularExpressions;
    
    namespace NumConvert {
    	class Program {
    		// basic reflection method - will accept "1,2,3.4" as well, because number.Parse accepts it
    		static T ParseReflect<T>(string s) where T:struct {
    			return (T)typeof(T).GetMethod("Parse", BindingFlags.Static|BindingFlags.Public, null, new Type[] {
    				typeof(string), typeof(NumberStyles), typeof(IFormatProvider) }, null)
    				.Invoke(null, new object[] { s, NumberStyles.Number, CultureInfo.InvariantCulture });
    		}
    		// regex check added
    		static string NumberFormat = @"^\d{1,3}(,\d{3})*(.\d+)?$";
    		static T ParseWithCheck<T>(string s) where T:struct {
    			if(!Regex.IsMatch(s, NumberFormat))
    				throw new FormatException("Not a number");
    			return ParseReflect<T>(s);
    		}
    		// caching (constructed automatically when used for the first time)
    		static Regex TestNumber = new Regex(NumberFormat);
    		static class ParseHelper<T> where T:struct {
    		//	signature of parse method
    			delegate T ParseDelegate(string s, NumberStyles n, IFormatProvider p);
    		//	static initialization by reflection
    			static ParseDelegate ParseMethod = (ParseDelegate)Delegate.CreateDelegate(
    				typeof(ParseDelegate), typeof(T).GetMethod("Parse",
    				BindingFlags.Static|BindingFlags.Public, null, new Type[] {
    				typeof(string), typeof(NumberStyles), typeof(IFormatProvider) }, null));
    		//	this can be customized for each type (and we can add specific format provider as well if needed)
    			static NumberStyles Styles = typeof(T) == typeof(decimal)
    				? NumberStyles.Currency : NumberStyles.Number;
    		//	combined together
    			public static T Parse(string s) {
    				if(!TestNumber.IsMatch(s))
    					throw new FormatException("Not a number");
    				return ParseMethod(s, Styles, CultureInfo.InvariantCulture);
    			}
    		}
    		// final version
    		static T Parse<T>(string s) where T:struct {
    			return ParseHelper<T>.Parse(s);
    		}
    		static void Main(string[] args) {
    			Console.WriteLine(Parse<double>("34,475.79333"));
    			Console.Read();
    		}
    	}
    }
