    private void Form1_Load(object sender, EventArgs e)
        {
            string password = "test";
            var keypressed = Observable.FromEventPattern<KeyPressEventHandler, KeyPressEventArgs>(
                    handler => handler.Invoke,
                    h => this.KeyPress += h,
                    h => this.KeyPress -= h);
            
            var keyDownSequence = keypressed.Select(p => p.EventArgs.KeyChar);
            var checkPasswordSequence = from n in keyDownSequence.Buffer(password.Length, 1)
                                        where string.Join("", n.ToArray()) == password
                                        select n;
            checkPasswordSequence.Subscribe(x => MessageBox.Show(string.Join("", x.ToArray())));
        }
