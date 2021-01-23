            //Regex regex = new Regex("(\\w{5})(\\d*)(\\w*)");
            Regex regex = new Regex("(\\w*)(\\d{6})([PC])(\\d*)");
            List<string> list = new List<string>();
            list.Add("AAPL7131221P00590000");
            list.Add("AAPL7131206C00595000");
            list.Add("AAPL7131213P00600000");
            List<string> extracted = new List<string>();
            foreach (string item in list)
            {
                extracted.Add(regex.Split(item)[2]);
            }
