    pauseTime = MyImage.Layer.TimeOffset;
    MyImage.Layer.Speed = 1.0f;
    MyImage.Layer.TimeOffset = 0.0f;
    MyImage.Layer.BeginTime = 0.0f;
    timeSincePause = (MyImage.Layer.ConvertTimeFromLayer(CAAnimation.CurrentMediaTime(), MyImage.Layer) - pauseTime);
    MyImage.Layer.BeginTime = timeSincePause;
