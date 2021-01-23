    bool _isFirst = true;
    bool _reachedBottomRight = false;
    bool _reachedTopRight = false;
    int _increDecreValue = 1;
    int StartXPos = 5;
    int StartYPos = 5;
    private void btnClicker_Click(object sender, EventArgs e)
    {
        if (_isFirst)
        {
            //Set the start location of the button. This can be any position you want
            btnClicker.Location = new Point(StartXPos, StartYPos);
            _isFirst = false;
        }
        if (btnClicker.Location.Y < this.ClientSize.Height - btnClicker.Height && !_reachedBottomRight)
            btnClicker.Location = new Point(btnClicker.Location.X, btnClicker.Location.Y + _increDecreValue);
        else if (btnClicker.Location.X < this.ClientSize.Width - btnClicker.Width && !_reachedTopRight)
            btnClicker.Location = new Point(btnClicker.Location.X + _increDecreValue, btnClicker.Location.Y);
        else if (btnClicker.Location.Y > StartYPos)
        {
            btnClicker.Location = new Point(btnClicker.Location.X, btnClicker.Location.Y - _increDecreValue);
            _reachedBottomRight = true;
        }
        else if (btnClicker.Location.X > StartXPos)
        {
            btnClicker.Location = new Point(btnClicker.Location.X - _increDecreValue, btnClicker.Location.Y);
            _reachedTopRight = true;
        }
        if (btnClicker.Location.X <= StartXPos && btnClicker.Location.Y <= StartYPos)
        {
            _reachedBottomRight = false;
            _reachedTopRight = false;
        }
    }
