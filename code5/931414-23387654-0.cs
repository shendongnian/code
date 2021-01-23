    string [] list = Directory.GetFiles(Server.MapPath("~"));
            StringBuilder sb=new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item + "\n");
            }
    
            Response.Write(sb);
