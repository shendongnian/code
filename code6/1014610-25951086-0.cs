    string s, result;
    bool bl = false;
    using (StreamReader sr = new StreamReader("....txt"))
    {
        while ((s = sr.ReadLine()) != null)
        {
            if(s.Contains ("two"))
            {
                bl = true;
            }
            if (s.Contains("id_number") && bl == true)
            {
                result = s.Replace("id_number:*=", "");
                textBox1.Text = result;
                break;
            }
        }
    }
