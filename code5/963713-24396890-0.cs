    ' Customers would be a database context of some form
    For Each C In Customers
        Dim MyData = <?xml version="1.0" encoding="UTF-8"?>
                     <Program xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="program.xsd">
                         <Customer>
                             <CId><%= C.CId %></CId>
                             <ClientName><%= C.ClientName %></ClientName>
                             <SubscriberId><%= C.SubscriberId %></SubscriberId>
                         </Customer>
                         <CreatedOn><%= C.CreatedOn %></CreatedOn>
                         <Message>
                             <MessageId DeliveryChannel=<%= C.DeliveryChannel %>>123456</MessageId>
                             <Prospect>
                                 <Id>12345678</Id>
                             </Prospect>
                             <SentDate>2014-06-24T12:00:01</SentDate>
                             <CName>x1</CName>
                             <CNameId>1234</CNameId>
                         </Message>
                         <Message>
                             <MessageId DeliveryChannel="2">1236457</MessageId>
                             <Prospect>
                                 <Id>12345679</Id>
                             </Prospect>
                             <SentDate>2014-06-24T12:00:02</SentDate>
                             <CName>x2</CName>
                             <CNameId>1235</CNameId>
                         </Message>
                     </Program>
        MyData.Save("filename here", SaveOptions.None)
    Next
