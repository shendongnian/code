    Vector3 _originalPosition;
    void OnMouseDown()
    {
        _originalPosition = gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        ...
    }
    void OnMouseUp()
    {
        gameObject.transform.position = _originalPosition;
    }
