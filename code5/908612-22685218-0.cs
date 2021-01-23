    public override Font Font
    {
        get
        {
            return base.Font;
        }
        set
        {
            textBox1.Font = base.Font = value;
            if (Font.Height != this.Height)
            {
                this.Height = Font.Height;
                textBox1.Size = new Size(this.Width - (_textboxMargin * 2 + _borderWidth * 2), this.Height - (_textboxMargin * 2 + _borderWidth * 2));
                textBox1.Location = new Point(_textboxMargin, _textboxMargin);
            }
        }
    }
    protected override void OnResize(EventArgs e)
    {
        if (this.Height < Font.Height)
            this.Height = Font.Height;
        base.OnResize(e);
    }
