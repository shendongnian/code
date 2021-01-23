    >>> l=System.Collections.Generic.List[System.Drawing.Point]\
    ([System.Drawing.Point(*(random.randint(1,1000) for _ in range(2))) for _ in range(5)])
    >>> l
    List[Point]([<System.Drawing.Point object at 0x0000000000000233 [{X=491,Y=874}]>
    , <System.Drawing.Point object at 0x0000000000000234 [{X=819,Y=595}]>, <System.D
    rawing.Point object at 0x0000000000000235 [{X=456,Y=625}]>, <System.Drawing.Poin
    t object at 0x0000000000000236 [{X=583,Y=29}]>, <System.Drawing.Point object at
    0x0000000000000237 [{X=329,Y=212}]>])
    >>> szr=System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
    >>> stm=System.IO.MemoryStream()
    >>> szr.Serialize(stm,l)
    >>> stm.Length
    481L
    >>> bytes=stm.GetBuffer()
    >>> s=System.Text.Encoding.Default.GetString(bytes)
    >>> s
    u'\x00\x01\x00\x00\x00\u044f\u044f\u044f\u044f\x01\x00\x00\x00\x00\x00\x00\x00\x
    0c\x02\x00\x00\x00QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyTo
    ken=b03f5f7f11d50a3a\x04\x01\x00\x00\x00\u040a\x01System.Collections.Generic.Lis
    t`1[[System.Drawing.Point, System.Drawing, Version=4.0.0.0, Culture=neutral, Pub
    licKeyToken=b03f5f7f11d50a3a]]\x03\x00\x00\x00\x06_items\x05_size\x08_version\x0
    4\x00\x00\x16System.Drawing.Point[]\x02\x00\x00\x00\x08\x08\t\x03\x00\x00\x00\x0
    5\x00\x00\x00\x00\x00\x00\x00\x07\x03\x00\x00\x00\x00\x01\x00\x00\x00\x05\x00\x0
    0\x00\x04\x14System.Drawing.Point\x02\x00\x00\x00\x05\u044c\u044f\u044f\u044f\x1
    4System.Drawing.Point\x02\x00\x00\x00\x01x\x01y\x00\x00\x08\x08\x02\x00\x00\x00\
    u043b\x01\x00\x00j\x03\x00\x00\x01\u044b\u044f\u044f\u044f\u044c\u044f\u044f\u04
    4f3\x03\x00\x00S\x02\x00\x00\x01\u044a\u044f\u044f\u044f\u044c\u044f\u044f\u044f
    \u0418\x01\x00\x00q\x02\x00\x00\x01\u0449\u044f\u044f\u044f\u044c\u044f\u044f\u0
    44fG\x02\x00\x00\x1d\x00\x00\x00\x01\u0448\u044f\u044f\u044f\u044c\u044f\u044f\u
    044fI\x01\x00\x00\u0424\x00\x00\x00\x0b\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\
    x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\
    x00'
