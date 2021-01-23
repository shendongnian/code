		using System;
		using System.Globalization;
		namespace Plurally
		{
			public class Pluralizer
			{
				//
				// Constructors
				//
				public Pluralizer (CultureInfo cultureInfo = null);
				//
				// Methods
				//
				public bool IsPlural (string word);
				public bool IsSingular (string word);
				public string Pluralize (string word);
				public string Singularize (string word);
			}
		}
