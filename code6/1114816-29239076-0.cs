    using System.Linq;
    using System.Collections.Generic;
            IEnumerable<ICoordinate> list=...;
            foreach(IExpirable expirable in list.OfType<IExpirable>())
            {
                ...
            }
