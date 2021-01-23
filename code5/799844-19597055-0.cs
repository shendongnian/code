   	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			StreamWriter archivo = new StreamWriter(@"C:\Users\Marcelo\Documents\Proyectos\database.txt");
			for (int i = 1; i <=10 ; i++)
			{
				archivo.Write(nombres[i] + " " + temp[i] + " " + cap[i]);
				if (i != nseries)
					archivo.Write("\r\n"); 
			}
			archivo.Close();
		}
		catch (Exception e)
		{
			Debug.WriteLine(e.Message);
			//MessageBox.Show(e.Message);
		}
	}
