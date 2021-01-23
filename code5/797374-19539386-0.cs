    private void UploadWholeFile(HttpContext context, List<FilesStatus> statuses)
    {
    	using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
    	{
    		var a= 1;
    
    		**cn.Open();**
    		
    		for (int i = 0; i < context.Request.Files.Count; i++)
    		{
    			var file = context.Request.Files[i];
    
    			var fullpath = "/Files/"  + Path.GetFileName(file.FileName)
    
    			file.SaveAs(fullpath);
    
    			**statuses.Add(new FilesStatus(fullName, file.ContentLength, fullpath));** 
    
    			**string sql1 = "insert into Imagem(FileName, Number, Id_Magazine, Tem_Conteudo) values (@FileName, @Number, @Id_Magazine, @Tem_Conteudo)";**
    
    			using (SqlCommand cmd = new SqlCommand(sql1, cn))
    			{
    				cmd.Parameters.AddWithValue("@NomeFicheiro", myfilename);
    				cmd.Parameters.AddWithValue("@Id_Magazine", context.Request.Form["MagazineId"]);
    				cmd.Parameters.AddWithValue("@Tem_Conteudo", false);
    				cmd.Parameters.AddWithValue("@Number", a++);
    				
    				**cmd.ExecuteNonQuery();**
    			}			
    		}
    		
    		**cn.Close();**
    	}
    }
