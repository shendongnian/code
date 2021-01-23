        static void Main( string[] args )
        {
            string Expression = "function(param1, param2)";            
            ///
            /// Get function name
            /// 
            var func = Regex.Match( Expression, @"\b[^()]+\((.*)\)$" );
            Console.WriteLine( "FuncTag: " + func.Value );
            string innerArgs = func.Groups[1].Value;
            ///
            /// Get parameters
            /// 
            var paramTags = Regex.Matches( innerArgs, @"([^,]+\(.+?\))|([^,]+)" );
            Console.WriteLine( "Matches: " + paramTags.Count );
            foreach( var item in paramTags )
                Console.WriteLine( "ParamTag: " + item );
            
        }
