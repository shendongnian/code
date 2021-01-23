            MatchCollection mclName;
            MatchCollection mclPrice;
            WebClient webClient = new WebClient();
            string strUrl = "http://www.pizzahut.com.pk/pizzas.html";
            byte[] reqHTML;
            reqHTML = webClient.DownloadData(strUrl);
            UTF8Encoding objUTF8 = new UTF8Encoding();
            string pageContent = objUTF8.GetString(reqHTML);
            Regex nameRegex = new Regex("<p class=\"MenuDescHead\">([A-Za-z\\s]+[0-9]*)");
            Regex priceRegex = new Regex("<p class=\"MenuDescPrice\">[^0-9]*([0-9]*)");
            mclName = nameRegex.Matches(pageContent);
            mclPrice = priceRegex.Matches(pageContent);
            StringBuilder strBuilder = new StringBuilder();
            List<string> menuPriceList = new List<string>();
            foreach (Match ml in mclPrice)
            {
                string price = ml.Groups[1].ToString();
                if (price != "" && price != "0")
                {
                    menuPriceList.Add(price);
                }
            }
            int j = 0;
            for (int i = 0; i < mclName.Count; i++)
            {
                string price;
                string name = mclName[i].Groups[1].ToString();
                if (i == 0 || i == 4)
                {
                    price = menuPriceList[j];
                    strBuilder.Append(name.Trim() + ", " + price.Trim() + " , PizzaHut\r\n");
                    j++;
                }
                price = menuPriceList[j];
                strBuilder.Append(name.Trim() + ", " + price.Trim() + " ,PizzaHut\r\n");
                j++;
            }
            Console.WriteLine(strBuilder.ToString());
