        DataSet myDataSet;
        myDataSet = null;
        try
        {
            if (strSheetName.Length > 0)
            {
                StringBuilder strConnectionString = new StringBuilder();
                strConnectionString.AppendFormat("Provider={0};", "Microsoft.ACE.OLEDB.12.0");
                strConnectionString.AppendFormat("Data Source={0};", strFilePath);
                strConnectionString.Append("Extended Properties=");
                strConnectionString.Append(((char)34).ToString()); //start of trickypart
                strConnectionString.Append("Excel 12.0 Xml;");
                // always treat contents of cells as text, which gives us full control/responsibility for casting to numeric when ncessary
                strConnectionString.Append(((char)34).ToString()); // end of tricky part
                string str = strConnectionString.ToString();
                OleDbConnection conn = new OleDbConnection(str);
                OleDbDataAdapter myCommand = new OleDbDataAdapter(" SELECT * FROM [" + strSheetName + "$] where QuestionDescription <>''", str);
                myDataSet = new DataSet();
                myCommand.Fill(myDataSet);
            }
            else
            {
                trError.Visible = true;
                lblError.Text = "File is Invalid format";
            }
        }
        catch
        {
            trError.Visible = true;
            lblError.Text = "Invalid format!!";
        }
        return myDataSet;
    }
   
