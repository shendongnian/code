    string input = textBox1.Text;
            string languagePair = "jp|en";
            string translation = "";
            string[] laynes = textBox1.Text.Split('\n');
            if (laynes.Length > 1)
            {
                string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string result = webClient.DownloadString(url);
                for (int i = 0; i < laynes.Length; i++)
                {
                    result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
                    if (i != laynes.Length - 1)
                    {
                        result = result.Substring(result.IndexOf(">") + 101);
                    }
                    else
                    {
                        result = result.Substring(result.IndexOf(">") + 1);
                    }
                    translation += result.Substring(0, result.IndexOf("</span>"));
                }
                //result = WebUtility.HtmlDecode(result.Trim()); <---- i didn't need this one since i translated from Japanese to English
                MessageBox.Show(translation.Replace("<br>", "\n"));
            }
            else
            {
                string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string result = webClient.DownloadString(url);
                result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
                result = result.Substring(result.IndexOf(">") + 1);
                result = result.Substring(0, result.IndexOf("</span>"));
                //result = WebUtility.HtmlDecode(result.Trim());
                MessageBox.Show(result.Replace("<br>", "\n"));
            }
