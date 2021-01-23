    for (int i = 0; i < measuredValues.Length; i++)
    {
        if (measuredValues[i] < -273)
            continue;
        if (qLeft.Count == 3)
            qLeft.Dequeue();
        for (int j = i + 1; j < measuredValues.Length; j++)
        {
            if (qRight.Count == 2)
            {
                break;
            }
            qRight.Enqueue(measuredValues[j]);
        }
        if (b(qLeft, qRight, measuredValues[i]) == true)
        {
            sum += measuredValues[i];
            cnt++;
        }
        qLeft.Enqueue(measuredValues[i]); // YOU NEED TO ENQUEUE INTO qLeft EACH TIME REGARDLESS OF IT IS VALID OR INVALID
        qRight.Clear();
    }
