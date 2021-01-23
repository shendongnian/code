    class AppleModel
    {
       int PipCount { get; set; }    // Auto Property
       Boolean isFresh {get ; set; } // Auto Property
    }
    class AppleView : PictureBox
    {
      private AppleModel _model; 
      public AppleView( AppleModel model )
      {
             this._model = model;
         .........
      }
      int PipCount 
      { 
       get { return this._model.PipCount; } 
       set { this._model.PipCount = value; }
      }
  
      int isFresh 
      { 
       get { return this._model.PipCount; } 
       set { this._model.PipCount = value; }
      }
    }
