      private string _description = string.Empty;
      public string Description
      {
         get
         {
            return _description;
         }
         set
         {
            var description = string.Empty;
            var substrings = value.Split( new[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries );
            for ( var i = 0; i < substrings.Length; i++ )
            {
               description += substrings[i] + ".";
               if ( i % 5 == 0 )
               {
                  description += Environment.NewLine;
               }
            }
            _description = description;
         }
      }
