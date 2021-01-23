        var s = Enumerable.Range(0, Math.Max(izmers1.Length, izmers2.Length)).Aggregate(new StringBuilder(), (sb, i) => 
            { 
                if (i < izmers1.Length) sb.Append(izmers1[i]); 
                if (i < izmers2.Length) sb.Append(izmers2[i]); 
                return sb; 
            }).ToString();
        }
