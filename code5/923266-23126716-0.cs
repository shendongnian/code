            private void OnResizeEnd(object sender, EventArgs e)
            {
                Paint += OnPaint;
            }
    
            private void OnResizeBegin(object sender, EventArgs e)
            {
                Paint -= OnPaint;
            }
