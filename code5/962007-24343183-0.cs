       foreach (XmlNode nodelist2 in nodeList)
           {//14  101517
            //int i = 0;//if (i == 0) { i++; }
               if (i < 1) //1
               {
                 switch (nodelist2.Name)
                  {
                    case "VertrekTijd": string kuttijd1 = (nodelist2.InnerText);
                    var res1 = Regex.Match(kuttijd1, @"\d{1,2}:\d{1,2}").Value;
                    lblv1.Text = Convert.ToString(res1); break;
                    case "VertrekVertragingTekst": var tobiasisnietvantexel1 = (nodelist2.InnerText); if (tobiasisnietvantexel1 == null) {} else{ ververt1.Text = tobiasisnietvantexel1; ververt1.Visible = true; vertpic1.Visible = true; logo1.Top -= 9; lblts1.Top -= 9; } break;
                    case "EindBestemming": string vertrek1 = (nodelist2.InnerText); if (vertrek1 == "Uitgeest") { lblvia1.Text = "Krommenie-Ass"; } lblbs1.Text = vertrek1; break;
                    case "TreinSoort": lblts1.Text = (nodelist2.InnerText); break;
                    case "RouteTekst": lblvia1.Text = (nodelist2.InnerText); break;
                    case "VertrekSpoor": lbls1.Text = (nodelist2.InnerText); i++;  break;
                    //Here's the case you might try adding
                    case "Opmerkingen": var SomeVar = OpmerkingenMethod(nodelist2); break; 
                    //or do something else that you want to do, instead of breaking,
                    //I do not know what you want to do with Opmerking when you get it
                    // so I just had the function output into another variable.
                   }
                }
           }
