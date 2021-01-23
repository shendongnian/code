    private void HIDE(){
                  if (textBox1.Text != "")
                  {
                      Bitmap bitmap = (Bitmap)pictureBox1.Image;
                      // Starting point for embedding secret
                      int x0=0, y0=0;
                      // Error checking, to see if text can fit in image
                      int imageSize = bitmap.Width * bitmap.Height;
                      if (imageSize - x0 * bitmap.Width - y0 < 8 * textBox1.Text.Length)
                      {
                          // Deal with error
                      }
                      // Ready to embed
                      for (int t = 0; t < textBox1.Text.Length; t++)
                      {
                          for (int i = 0; i < 8; i++)
                          {
                              // Check if y0 has exceeded image width
                              // so to wrap around to the new row
                              if (y0 == bitmap.Width)
                              {
                                  x0++;
                                  y0=0;
                              }
                              // x0, y0 are now the current pixel coordinates
                              //
                              // EMBED MESSAGE HERE
                              //
                              y0++;  // Move to the next pixel for the next bit
                          }
                      }
                  }}
