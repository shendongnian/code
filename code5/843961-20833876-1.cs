    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	string str2 = "";
    	if (saveFileDialog1.FileName != null)
    	{
    		str2 = saveFileDialog1.FileName;
    		if (!File.Exists(str2))
    		{
    			SQLiteConnection.CreateFile(saveFileDialog1.FileName);
    		}
    	}
    
    	SQLiteConnection connection = new SQLiteConnection("Data Source=" + saveFileDialog1.FileName);
    	connection.Open();
    
    	SQLiteCommand newcdbdatas = DatabaseHelper.CreateCommand("create table datas (id integer, ot integer, alias integer, setcode integer, type integer, atk integer, def integer, level integer, race integer, attribute integer, category integer)", connection);
    	SQLiteCommand newcdbtexts = DatabaseHelper.CreateCommand("create table texts (id integer, name varchar(128), desc varchar(1024), str1 varchar(256), str2 varchar(256), str3 varchar(256), str4 varchar(256), str5 varchar(256), str6 varchar(256), str7 varchar(256), str8 varchar(256), str9 varchar(256), str10 varchar(256), str11 varchar(256), str12 varchar(256), str13 varchar(256), str14 varchar(256), str15 varchar(256), str16 varchar(256), str17 varchar(256), str18 varchar(256), str19 varchar(256))", connection);
    	DatabaseHelper.ExecuteNonCommand(newcdbdatas);
    	DatabaseHelper.ExecuteNonCommand(newcdbtexts);
    
    	SQLiteCommand command = null;
    	
    	///////I added somthing here//////////
    	var progressCounter = 0;
    	var max = Program.CardData1.Keys.Count;
    	///////////////////////////////////////
    	
    	foreach (int id in Program.CardData1.Keys)
    	{
    		int cardid = Program.CardData1[id].Id;
    		int ot = Program.CardData1[id].Ot;
    		int cardalias = Program.CardData1[id].AliasId;
    		int atk = Program.CardData1[id].Atk;
    		int def = Program.CardData1[id].Def;
    
    		command = DatabaseHelper.CreateCommand("INSERT INTO datas (id,ot,alias,setcode,type,atk,def,level,race,attribute,category)" +
    					 " VALUES (@id, @ot, @alias, @setcode, @type, @atk, @def, @level, @race, @attribute, @category)", connection);
    
    		command.Parameters.Add(new SQLiteParameter("@id", cardid));
    		command.Parameters.Add(new SQLiteParameter("@ot", ot));
    		command.Parameters.Add(new SQLiteParameter("@alias", cardalias));
    		command.Parameters.Add(new SQLiteParameter("@setcode", Program.CardData1[id].SetCode));
    		command.Parameters.Add(new SQLiteParameter("@type", Program.CardData1[id].Type));
    		command.Parameters.Add(new SQLiteParameter("@atk", atk));
    		command.Parameters.Add(new SQLiteParameter("@def", def));
    		command.Parameters.Add(new SQLiteParameter("@level", Program.CardData1[id].Level));
    		command.Parameters.Add(new SQLiteParameter("@race", Program.CardData1[id].Race));
    		command.Parameters.Add(new SQLiteParameter("@attribute", Program.CardData1[id].Attribute));
    		command.Parameters.Add(new SQLiteParameter("@category", Program.CardData1[id].Category));
    		DatabaseHelper.ExecuteNonCommand(command);
    		command = DatabaseHelper.CreateCommand("INSERT INTO texts (id,name,desc)" +
    			" VALUES (@id,@name,@des)", connection);
    		command.Parameters.Add(new SQLiteParameter("@id", cardid));
    		command.Parameters.Add(new SQLiteParameter("@name", Program.CardData1[id].Name));
    		command.Parameters.Add(new SQLiteParameter("@des", Program.CardData1[id].Description));
    		DatabaseHelper.ExecuteNonCommand(command);
    		
    		///////I added somthing here//////////
    		progressCounter++;
    		var progressPercentage = progressCounter*100/max;
    		backgroundWorker1.ReportProgress(progressPercentage);
    		///////////////////////////////////////
    	}
    	connection.Close();
    }
