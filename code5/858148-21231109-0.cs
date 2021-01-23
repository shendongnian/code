    string[] days = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
           
            string week = "week ";
            StringBuilder sb = new StringBuilder();
            sb = sb.Append(' ',week.Length+2);
            for(int i=0;i<days.Length;i++)
            {
                sb = sb.Append(days[i].ToString());
                sb = sb.Append(' ',5);
            }
            
            sb = sb.Append("\n");
            for (int i = 0; i < productsArray.GetLength(0); i++)
            {
                sb = sb.Append("week " + (i + 1) + " ");
                for (int j = 0; j < productsArray.GetLength(1); j++)
                {
                    sb = sb.Append(productsArray[i, j].ToString().PadLeft(days[j].Length));
                    sb = sb.Append(' ', 5);
                }
                sb = sb.Append("\n");
            }
            Console.WriteLine(sb.ToString());
