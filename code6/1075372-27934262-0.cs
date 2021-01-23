    string FixName(string name)
        {
            StringBuilder sb=new StringBuilder();
            var ar=name.Replace('.',' ').Split(' ');
            for (int i = 0; i < ar.Length; i++)
            {
                sb.Append(ar[i]);
                if (i < ar.Length - 1 && ar[i+1].Length>1)
                    sb.Append(" ");
            }
            return sb.ToString();
        }
