    foreach (List<string> myStrings in Screen.AllScreens.Select(myScreen => _xml.GetScreenConfigs(i)))
    {
         // ...
                int i1 = i;
                List<string> strings = myStrings;
                var myMarketing = new Marketing(i1, strings[0]);
                myMarketing.Show();
            }
            else
            {
                // ...
            }
        }
        i++;
    }
