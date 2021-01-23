    public static implicit operator vector2D<T1>(vector2D<uint> src)
            {
                return new vector2D<T1>
                    {
                        m_h = (T1)Convert.ChangeType(src.m_h, typeof(T1)),
                        m_w = (T1)Convert.ChangeType(src.m_w, typeof(T1)),
                    };
            }
