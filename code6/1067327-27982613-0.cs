    _Line = 0; 
    void printDocument1_PrintPage( object sender, System.Drawing.Printing.PrintPageEventArgs e )
                    
                {
                    float lineHeight = NormalFont.GetHeight(e.Graphics) + 4;
         
                        float yLineTop = e.MarginBounds.Top;
                        yLineTop = yLineTop + 100;
                        for ( ; _Line <= 100 ; _Line++ )
                        {
                            if ( yLineTop + lineHeight > e.MarginBounds.Bottom )
                            {
                                e.HasMorePages = true;
                                return;
                            }
         
                            e.Graphics.DrawString( "TEST: " + _Line, NormalFont, Brushes.Black, new PointF( e.MarginBounds.Left, yLineTop ) );
                            yLineTop += lineHeight;
                        }
                        e.HasMorePages = false;
                  
                }
