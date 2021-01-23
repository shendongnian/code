    void textbox_textChanged(object sender, EventArgs e)
        {
            string text = textBox.Text;
            int pointCounter = 0;
            int addCounter =0
            string temp = "";
            string numbers = "0123456789";
            for(int i =0;i<text.Length;i++)
            {
                bool found = false;
                for(int j = 0;j<numbers.Length;j++)
                {
                    if(text[i]==numbers[j])
                    {
                        temp+=text[i];
                        found = true;
                        break;
                    }
                }
                if(!found)
                {
                    if('.' == text[i])
                    {
                        if(pointCounter<1)
                        {
                            pointCounter++;
                            temp+=text[i];
                        }
                    }else
                        if('+' == text[i])
                        {
                            if(addCounter<1)
                            {
                                pointCounter=0;
                                addCounter++;
                                temp+=text[i];
                            }
                        }
                }
            }
            textBox.text = temp;
        }
