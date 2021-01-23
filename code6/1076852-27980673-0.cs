    Timer tm = new Timer(ChangeColor, cameraObject, 0, 1000);
        private void ChangeColor(object camera)
        {
            //camera is your camera object
            if (camera != null)
            {
                camera.backgroundColor = Color.red;
            }
        }
