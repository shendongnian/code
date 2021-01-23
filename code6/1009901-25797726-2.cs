    i = 0;
    sum = 0;
    while (i < prob.Length)
    {
        sum += prob[i];
    }
    pick = rnd.Next(sum); // 0..sum-1
    i = 0;
    while (pick >= prob[i])
    {
        pick -= prob[i];
        i++;
    }
    // i is now the index of the name picked
