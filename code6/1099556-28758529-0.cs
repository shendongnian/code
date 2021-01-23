    i = 0;
    query.Where(c => c != vowels[i]);
    i = 1;
    query.Where(c => c != vowels[i]).Where(c => c != vowels[i]);
    i = 2;
    query.Where(c => c != vowels[i]).Where(c => c != vowels[i]).Where(c => c != vowels[i]);
    ...
