        public override void Write(char value)
        {
            var text = value.ToString();
            this._output.Invoke(new Action(() => this._output.AppendText(text)));
        }
