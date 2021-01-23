    b1.Click += btnClick;
    b2.Click += btn2Click;
    b3.Click += btn3Click;
    
    void btnClick(...)
    {
      ...
    
      // perform a click on different button after the user has clicked a button.
      btn2Click(...);
      btn3Click(...);
    }
