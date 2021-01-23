            var tec = TextEditorChild;
            FormClosingEventHandler closing = null;
            closing = (s, e) =>
            {
                tec.FormClosing -= closing;
                if (--count == 0)
                {
                    timer.Enabled = false;
                }
            };
            tec.FormClosing += closing;
