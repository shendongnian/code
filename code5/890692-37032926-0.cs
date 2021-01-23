    private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Dictionary<string, object>> topicsList = topicParser.Parse(topicsXDocument.Root);
            Console.WriteLine("The Topics List contains:");
            foreach (Dictionary<string, object> topic in topicsList)
            {
                foreach (KeyValuePair<string, object> element in topic)
                {
                    string name = element.Key;
                    object content = element.Value;
                    Console.WriteLine("Key: {0}, Value: {1}", name, content.ToString());
                }
            }
            
        }
