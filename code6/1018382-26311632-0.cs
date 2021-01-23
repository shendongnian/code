    class RectangleWithText
    {
        RectangleF m_extent = new RectangleF();
        string m_text = "";
        Font m_textFont = null;
        RectangleF m_textRect = new RectangleF();
        public RectangleWithText( RectangleF extent, string text )
        {
            m_extent = extent;
            m_text = text;
        }
        public void Draw( Graphics g )
        {
            var dashedGrayPen = new Pen( Color.Gray, 1.0f / g.DpiX ) { DashStyle = DashStyle.Dash };
            var brownPen = new Pen( Color.Brown, 1.0f / g.DpiX );
            // Draw rectangle itself
            g.DrawRectangle( brownPen, m_extent.X, m_extent.Y, m_extent.Width, m_extent.Height );
            // Draw text on it
            var extentCenter = new PointF( ( m_extent.Left + m_extent.Right ) / 2, ( m_extent.Bottom + m_extent.Top ) / 2 );
            DrawText( g, m_text, extentCenter, m_extent );
            }
        }
        private void DrawText( Graphics g, string text, PointF ptStart, RectangleF extent )
        {
            var gs = g.Save();
            // Inverse Y axis again - now it grow down;
            // if we don't do this, text will be drawn inverted
            g.ScaleTransform( 1.0f, -1.0f, MatrixOrder.Prepend );
            if ( m_textFont == null )
            {
                // Find the maximum appropriate text size to fix the extent
                float fontSize = 100.0f;
                Font fnt;
                SizeF textSize;
                do
                {
                    fnt = new Font( "Arial", fontSize / g.DpiX, FontStyle.Bold, GraphicsUnit.Pixel );
                    textSize = g.MeasureString( text, fnt );
                    m_textRect = new RectangleF( new PointF( ptStart.X - textSize.Width / 2.0f, -ptStart.Y - textSize.Height / 2.0f ), textSize );
                    var textRectInv = new RectangleF( m_textRect.X, -m_textRect.Y, m_textRect.Width, m_textRect.Height );
                    if ( extent.Contains( textRectInv ) )
                        break;
                    fontSize -= 1.0f;
                    if ( fontSize <= 0 )
                    {
                        fontSize = 1.0f;
                        break;
                    }
                } while ( true );
                m_textFont = fnt;
            }
            // Create a StringFormat object with the each line of text, and the block of text centered on the page
            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString( text, m_textFont, Brushes.Black, m_textRect, stringFormat );
            g.Restore( gs );
        }
    }
