    if (someCondition)
        Console.WriteLine("someCondition is true!");
    Console.WriteLine("I run regardless");
    // same as
    if (someCondition)
    {
        Console.WriteLine("someCondition is true!");
    }
    using (var s = new SecureString())
        Console.WriteLine(s); // this works!
    //Console.WriteLine(s); // s is no longer in scope, this won't compile
