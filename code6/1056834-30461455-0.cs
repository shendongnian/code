    foreach (var thisFrame in frames)
    {
            GC.Collect();
            try
            {
                   MediaClip clip = await MediaClip.CreateFromImageFileAsync(thisFrame, TimeSpan.FromMilliseconds(36 * speed));
                   app.mediaComposition.Clips.Add(clip);
            }
            catch (Exception ex)
            {
                   Debug.WriteLine(ex.Message + ex.StackTrace);
            }
    }
