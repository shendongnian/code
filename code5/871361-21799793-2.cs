	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
    using Novacode;
    static void Main(string[] args)
    {
        var wordsA = ExtractWords(DocX.Load(Path.Combine(mydocumentPath, @"DocumentA.docx")));
        var wordsB = ExtractWords(DocX.Load(Path.Combine(mydocumentPath, @"DocumentB.docx")));
        ReduceToDifferences(wordsA, wordsB);
        Console.WriteLine("------ Words only in A:");
        PrintList(wordsA);
        Console.WriteLine("------ Words only in B:");
        PrintList(wordsB);
        Console.WriteLine("------ Press any key");
        Console.ReadLine();
    }
	private static void PrintList(IList<string> wordsA)
    {
        foreach (var word in wordsA)
        {
            Console.WriteLine(word);
        }
    }
