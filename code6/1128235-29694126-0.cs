        private bool IsWinner(Image opponent)
        {
            foreach (PictureBox box in pictureBoxes)
            {
                if (
                    (box.Image != null)
                    && (box.Image == opponent)
                    )
                {
                    return false;
                }
            }
            return true;
        }
