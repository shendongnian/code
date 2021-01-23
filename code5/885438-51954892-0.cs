            string fName = @hdfRuta.Value; //Ruta donde se encuentra el archivo txt Ejm: c:\log\log21082018.txt
            System.IO.FileStream fs = System.IO.File.Open(fName, 
            System.IO.FileMode.Open);
            byte[] btFile = new byte[fs.Length];
            fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + hdfNombreArchivo.Value); //hdfNombreArchivo: Nombre del archivo .txt a generarse Ejm: Log_21_08_2018.txt
            EnableViewState = false;
            Response.ContentType = "text/plain";  
            Response.BinaryWrite(btFile);
            Response.End();
        protected void btnBajarLog_PreRender(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ScriptManager newScriptManager = 
           (ScriptManager)Page.FindControl("scmRegistroMasivoEvento");
            newScriptManager.RegisterPostBackControl(btn);
        }
