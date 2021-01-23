     public partial class WiiMoteControl: PictureBox {
       
        public Bitmap wiimote;
        private float _angle;
        public float Angle { 
             get { return _angle; } 
             set { _angle = value; Invalidate( ); } 
        }
        protected override void OnPaint( PaintEventArgs pe ) {
            base.OnPaint( pe );
            pe.Graphics.ResetTransform( );
            pe.Graphics.TranslateTransform( Size.Width / 2, Size.Height / 2 );
            pe.Graphics.RotateTransform( Angle );
            pe.Graphics.TranslateTransform( -Size.Width / 2, -Size.Height / 2 );
            if (wiimote != null) {
                pe.Graphics.DrawImage( wiimote, 0, 0, Size.Width, Size.Height );
            }
        }
    }
