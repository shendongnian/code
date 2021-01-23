    float timer;
    void Start()
    {
        timer = 0;
    }
  
    void Update()
    {
        timer += Time.deltaTime;
        if (playerDistance <= 38 && playerDistance > 21)
        {
              myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
              if (timer > 3.0f)
              {
                  spawner.SendMessage("shoot");
                  timer = 0;
              }
        }
    }
