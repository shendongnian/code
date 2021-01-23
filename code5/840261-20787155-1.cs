            if (settings.HDRpass)
            {   //HDR Rendering passes
                //Uses Hardware bilinear downsampling method to obtain 1x1 texture as scene average
                Game1.graphics.GraphicsDevice.SetRenderTarget(HDRsampling[0]);
                Game1.graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 0, 0);
                downsampler.Parameters["maxX"].SetValue(HDRsampling[0].Width);
                downsampler.Parameters["maxY"].SetValue(HDRsampling[0].Height);
                downsampler.Parameters["scene"].SetValue(renderOutput);
                downsampler.CurrentTechnique.Passes[0].Apply();
                quad.Render();
                for (int i = 1; i < HDRsampling.Length; i++)
                {   //Downsample the scene texture repeadetly until last HDRSampling target, which should be 1x1 pixel
                    Game1.graphics.GraphicsDevice.SetRenderTarget(HDRsampling[i]);
                    Game1.graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 0, 0);
                    downsampler.Parameters["maxX"].SetValue(HDRsampling[i].Width);
                    downsampler.Parameters["maxY"].SetValue(HDRsampling[i].Height);
                    downsampler.Parameters["scene"].SetValue(HDRsampling[i-1]);
                    downsampler.CurrentTechnique.Passes[0].Apply();
                    quad.Render();
                }
                //assign the 1x1 pixel
                downsample1x1 = HDRsampling[HDRsampling.Length - 1];
                Game1.graphics.GraphicsDevice.SetRenderTarget(extract);
                //switch out rendertarget so we can send the 1x1 sample to the shader.
                bloom.Parameters["downSample1x1"].SetValue(downsample1x1);
            }
