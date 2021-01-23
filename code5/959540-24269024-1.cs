    const float swipeThreshold = 100.0f;
    IEnumerator SwipeInput(Action<Vector2> onSwipe)
    {
        Dictionary<int, Touch> activeTouches = new Dictionary<int, Touch>();
        Dictionary<int, Vector3> activeButtons = new Dictionary<int, Vector3>();
        while (true)
        {
            if (Input.touches.Length > 0)
                foreach (Touch touch in Input.touches)
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            activeTouches[touch.fingerId] = touch;
                            break;
                        case TouchPhase.Ended:
                            if (activeTouches.ContainsKey(touch.fingerId))
                            {
                                Vector2 delta = touch.position - activeTouches[touch.fingerId].position;
                                if (delta.magnitude > swipeThreshold)
                                    onSwipe(delta);
                            }
                            break;
                    }
            else
                for (int i = 0; i <= 2; ++i)
                {
                    if (Input.GetMouseButtonDown(i))
                        activeButtons[i] = Input.mousePosition;
                    else if (Input.GetMouseButtonUp(i) && activeButtons.ContainsKey(i))
                    {
                        Vector2 delta = Input.mousePosition - activeButtons[i];
                        if (delta.magnitude > swipeThreshold)
                            onSwipe(delta);
                    }
                }
            yield return new WaitForFixedUpdate();
        }
    }
