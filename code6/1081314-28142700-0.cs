    public partial class Form1 : Form
    {
        Label sentenceOutputLabel = new Label();
        public Form1()
        {
            InitializeComponent();
            int padding = 10;
            // Add a label to the form
            sentenceOutputLabel.Width = ClientSize.Width - (padding * 2);
            sentenceOutputLabel.Top = padding;
            sentenceOutputLabel.Left = padding;
            sentenceOutputLabel.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(sentenceOutputLabel);
            // List of words that, for each one, we'll add a button to the form
            // Note that some words have two parts: the first part is the button 
            // text, followed by a colon, then followed by the tag text. We split
            // these out later, when assigning button properties
            var words = new List<string>
            {
                "A", "a", "An", "an", "The", "the", "man", "woman", "dog", "cat", 
                "car", "bicycle", "beautiful", "big", "small", "strange", "looked",
                "rode", "spoke", "laughed at", "drove", "[space]: ", "[period]:.",
                "[exclamation]:!"
            };
            // Get the width of the longest word so we size the buttons accordingly
            int width;
            using (Graphics cg = CreateGraphics())
            {
                width = Convert.ToInt32(cg.MeasureString(words.Aggregate("", (max, cur) =>
                    (cg.MeasureString(max, new Button().Font).Width) >
                    (cg.MeasureString(cur, new Button().Font).Width)
                        ? max
                        : cur), new Button().Font).Width);
            }
            
            // Add the buttons to the form, spacing them evenly
            int left = padding;
            int top = sentenceOutputLabel.Bottom + padding;
            int bottomOfLastButton = 0;
            foreach (var word in words)
            {
                // For some words, we have a colon-separated symbol that we 
                // will use instead of the word (like 'space', for example)
                // So we store the symbol in the 'Tag' property and the word
                // in the text property.
                var wordParts = word.Split(':');
                var text = wordParts[0];
                var tag = wordParts.Length > 1 ? wordParts[1] : text;
                var button = new Button
                {
                    Text = text,
                    Tag = tag,
                    Left = left,
                    Top = top,
                    Width = width,
                    Visible = true
                };
                // HERE WE ADD A COMMON CLICK EVENT
                button.Click += wordButton_Click;
                // Add the button to the form
                Controls.Add(button);
                // Reset left and top if we're going past the width of the form
                left += (width + padding);
                if (left + width + padding > ClientSize.Width)
                {
                    left = padding;
                    top += button.Height + padding;
                }
                bottomOfLastButton = button.Bottom;
            }
            // Add a clear and exit button
            var exitButton = new Button
            {
                Top = bottomOfLastButton + (padding * 2),
                Text = "Exit",
                Left = ClientSize.Width - padding - width,
                Width = width
            };
            exitButton.Click += exitButton_Click;
            var clearButton = new Button
            {
                Top = bottomOfLastButton + (padding * 2),
                Text = "Clear",
                Left = exitButton.Left - padding - width,
                Width = width
            };
            clearButton.Click += clearButton_Click;
            Controls.Add(exitButton);
            Controls.Add(clearButton);
        }
        void clearButton_Click(object sender, EventArgs e)
        {
            sentenceOutputLabel.Text = "";
        }
        void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        void wordButton_Click(object sender, EventArgs e)
        {
            var wordButton = sender as Button;
            if (wordButton != null)
            {
                sentenceOutputLabel.Text += wordButton.Tag;
            }
        }
    }
