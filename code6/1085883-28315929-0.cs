    foreach (ManagementObject FailData in FailDataSet)
    {
        Byte[] data =(Byte[])FailData.Properties["VendorSpecific"].Value;
        var sb = new StringBuilder();
        for (int i = 0; i < data[0]; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                int dataIndex = i * 12 + j + 1;
                string textForColumn = j == 2 ?
                    GetAttributeText(data[dataIndex]) : data[dataIndex].ToString();
                richTextBox2.Text = richTextBox2.Text + textForColumn + "\t";
                sb.Append(textForColumn + "\t");
            }
            richTextBox2.Text = richTextBox2.Text + "\n";
            sb.AppendLine();
        }
        String title = "Unknw\tUnknw\tAttribute\tStatus\tUnknw\tValue\tWorst\tRaw\t\tUnknw\r\n";
        File.WriteAllText(@"C:\Users\Desktop\WriteText1.txt", title + sb.ToString();
    }
