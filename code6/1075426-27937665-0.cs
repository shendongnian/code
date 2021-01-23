        public string shapes = "circle, circle, square";
        private void button1_Click(object sender, EventArgs e)
        {
            shapes = shapes + ",";
            int comma = shapes.IndexOf(",");
            string value = shapes.Substring(0, comma).Trim();
            shapes = shapes.Replace(value, "").Trim(", ".ToCharArray());
            bool AllTheSame = (shapes.Length == 0);
            if (AllTheSame)
                Console.WriteLine("They are all: " + value);
            else
                Console.WriteLine("They are NOT all the same.");
        }
