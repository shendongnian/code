            try {
                        DoUI(() =>
                        {
                            mainframe.listBox1.Items.Clear();
                        });
                        for (int i = 0; i < client.clientnameList.Count; i++) {
                            DoUI(() =>
                            {
                                mainframe.listBox1.Items.Add(client.clientnameList[i]);
                            });
                        }
                } catch (ObjectDisposedException e) {
                        Console.WriteLine(e.StackTrace);
                }
