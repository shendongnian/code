    private void button2_Click(object sender, EventArgs e)
        {
        	for (i = 0; i < listBox1.Items.Count; i++)
        	{      
        		try
        		{
        			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(listBox1.Items[i].ToString());
        			if (response.StatusCode == HttpStatusCode.OK)
        			{
        				listBox3.Items.Add(listBox1.Items[i].ToString());
        			}
        		}
        		catch(Exception)
        		{
        			continue;
        		}
        	}
        }
