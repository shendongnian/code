    // 'this' is obviously the parent form/control
    this.MouseDown += ParentControl_MouseDown;
    this.MouseUp += ParentControl_MouseUp;
    this.MouseMove += ParentControl_MouseMove;
    // attach all child piece controls also
    foreach (var piece in GetAllPieces())
    {
        piece.MouseDown += ParentControl_MouseDown;
        piece.MouseUp += ParentControl_MouseUp;
        piece.MouseMove += ParentControl_MouseMove;
    }
