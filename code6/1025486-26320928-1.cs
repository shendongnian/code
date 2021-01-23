            Dim a, b, c, d As Integer
            a = 16
            a.Assign(b)
            a.Assign(c, d)
            Console.Write("b = {0}; c = {1}; d = {2}", New Object() {b, c, d})
            a = 99
            a.Assign(b, c, d)
            Console.Write("b = {0}; c = {1}; d = {2}", New Object() {b, c, d})
