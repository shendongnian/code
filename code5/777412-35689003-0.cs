        public static string[] SplitArrey(string[] ArrInput, int n_column)
        {
            
            string[] OutPut = new string[n_column];
            int NItem = ArrInput.Length; // Numero elementi
            int ItemsForColum = NItem / n_column; // Elementi per arrey
            int _total = ItemsForColum * n_column; // Emelemti totali divisi
            int MissElement = NItem - _total; // Elementi mancanti
            int[] _Arr = new int[n_column];
            for (int i = 0; i < n_column; i++)
            {
                int AddOne = (i < MissElement) ? 1 : 0;
                _Arr[i] = ItemsForColum + AddOne;
            }
            int offset = 0;
            for (int Row = 0; Row < n_column; Row++)
            {
                for (int i = 0; i < _Arr[Row]; i++)
                {
                    OutPut[Row] += ArrInput[i + offset] + " "; // <- Here to change how the strings are linked 
                }
                offset += _Arr[Row];
            }
            return OutPut;
        }
