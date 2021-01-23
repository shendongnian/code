    foreach (ManagementObject FailData in FailDataSet)
    {
        Byte[] data =(Byte[])FailData.Properties["VendorSpecific"].Value;
        var sb = new StringBuilder();
        for (int i = 0; i < data[0] - 1; i++)
        {
            for (int j = 0; j < 12; j++)
            {  
    			string text = data[i * 12 + j];
    			if (j == 2)
    				text = GetText(text);
                sb.Append(text + "\t");
            }
            sb.AppendLine();
        }
        richTextBox2.Text = sb.ToString();
        String title = "Unknw\tUnknw\tAttribute\tStatus\tUnknw\tValue\tWorst\tRaw\t\tUnknw\r\n";
        File.WriteAllText(@"C:\Users\Desktop\WriteText1.txt", title + sb.ToString());
    }
