    Module Module1
        Public Class Money
            Public Property Name As String
            Public Property Money As Decimal
        End Class
        Function IncreaseMe(ByRef currentSum As Decimal, value As Decimal) As Decimal
            currentSum += value
            Return currentSum
        End Function
        Sub Main()
            Dim listMoney As New List(Of Money)
            Dim total As Decimal = 0
            listMoney.Add(New Money With {.Money = 10, .Name = "aaa"})
            listMoney.Add(New Money With {.Money = 5, .Name = "bbb"})
            listMoney.Add(New Money With {.Money = 15, .Name = "ccc"})
            listMoney.Add(New Money With {.Money = 15, .Name = "ddd"})
            Dim query = From moneyItem In listMoney
                        Select New With {.Name = moneyItem.Name, .Money = moneyItem.Money, .Sum = IncreaseMe(total, moneyItem.Money)}
            For Each queryItem In query
                Console.WriteLine("{0}{3}{1}{3}{2}", queryItem.Name, queryItem.Money, queryItem.Sum, vbTab)
            Next
            Console.WriteLine("Total money: {0}", total)
            Console.ReadLine()
        End Sub
    End Module
